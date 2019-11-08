# Redis con ASP.Net⚙️

## Introduccion

### Descripción y contexto 📋
--- 
Se requiere la utilizacion de un base de datos no relacionales que genere un cache para la optimizacion de tiempos y ahorro de recursos.
Para realizar esta tarea se decidio optar por REDIS.

Redis es un motor de base de datos en memoria, basado en el almacenamiento en tablas de hashes (clave/valor) pero que opcionalmente puede ser usada como una base de datos durable o persistente.

Para poder utilizar REDIS, se genero una API con c#.

Actualmente, la Base de REDIS tiene 5 tipos de registros:
- Telefono
- E-Mail
- Persona
- DNI
- Nro Tributario

Se solicito que para la busqueda de una Persona haya 3 KEY diferentes:
- PERSONA ( ID )
- DNI 
- Nro Tributario

Esto para realizar busquedas mas simples sin la necesidad de hacer una Query.

Se acordo la arquitectura de Master-Slave para la mejor administracion de la base. Se realizo la implementacion de la funcion de Redis PUB/SUB para la notificacion de modificaciones en la base.

Se crearon 5 canales y las modificaciones correspondientesen el codigo para que al realizar un cambio, publique un mensaje.

### Sintesis de funcionamiento de REDIS🖇️
---
Redis es un base de datos no relacional, esto significa que no se pueden guardar KEYS foraneas. 

Redis tampoco sirve para querys, su fuerte esta en pasarle una Key especifica y no hacer una busqueda. 

Redis funciona como un diccionario, este tiene una ```KEY``` y una ```VALUE```. 
Esta ```KEY``` y ```VALUE``` son de formato string. 

Esto significa que a la hora de generar un registro, se va a tener que hacer en el formato ```SET KEY VALUE```
Para obtener un valor ```GET KEY```
Mas adelante se detallara mas en profundo como se utilizo ya que hay muchas mas formas de guardar un valor.

### Primeros Pasos con REDIS🖇️
---
En un terminal de PowerShell/Linux 

#### Para iniciar un servidor REDIS
- ```redis-server```

#### Para conectarse un servidor REDIS
- ```redis-cli -h IP PORT```

El puerto si esta por default se puede obviar. 

Ejemplo: ```redis-cli -h 192.XXX.XXX.XXX```

### Comandos Basicos de REDIS🖇️
---
#### Agregar un registro basico
- ```SET KEY VALUE```

#### Consultar un registro basico
- ```GET KEY VALUE```

#### Borrar un registro
- ```DEL KEY```

#### Agregar un registro con HASH
- ```HSET KEY HASH VALUE```

#### Consultar un registro HASH
- ```HGET KEY HASH VALUE```

## Implementacion🔧

### Investigacion 🔧
---
Se realizaron arduas pruebas con 2 framework para C# que abstraigan la complejidad de ingresos/obtencion de datos  a REDIS.
- ServiceStack:  Es un framework pago
- StackExchange: Es un framework free

Actualmente el sistema tiene StackExchange ya que las funciones que proporciona son mas que suficientes para la complejidad del sistema.

Se realizaron pruebas de tiempos de consultas. Al buscar KEYS que mattchearan con un patron , con 600.000 registros, los tiempos fueron de 10 segundos.

Al realizar un busqueda con una KEY especifica, los tiempos son en milisegundos. 

#### Uso de HASH para guardar registros en REDIS
Al momento de realizar pruebas con objetos y REDIS, se verifico que los frameworks guardan mejor las relaciones de objetos al estar en formato HASH la value. Para eso se tuve que realizar pruebas comparativas con un ```SET KEY VALUE``` y un ```HSET KEY HASH VALUE```.

Se verifico que el hash ayuda a poder guardar relaciones de objetos en la base de REDIS sin necesidad de realizar conversiones.

Esto sirve por si no se trabaja con API y se trabajo con los objetos.

#### Creacion de un Master y un Slave
Despues de consultar varios manuales y explicaciones, obtuve los datos necesarios para crear un slave con unos simples pasos los cuales describo en la seccion de implementacion.

### Crear un Slave de un Master 🔧
---
se modifica el archivo: sudo nano /etc/redis/redis.conf. Se deben modificar un par de lineas.

#### Prioridad
Es el orden en el que se utilizaran las instancias que tengamos. Cuanta más baja sea la prioridad, más alta será la posibilidad de que esta instancia sea la utilizada en caso de caída.
- ```slave-priority 100 => slave-priority 10```

#### IP MASTER
- ```bind IpLocal => bind IpMaster```

#### Slave OF
Dado que esta instancia de réplica, tenemos que añadir la siguiente línea:

-```slaveof IpMaster PortMaster```

#### Para finalizar es necesario reiniciar el equipo y verificar que en la pantalla del Master figure ```Synchronization with slave IpSlave:6379 succeeded```

### Funcion Pub/Sub Redis 🔧

Se solicita la implementacion de esta funcion de redis en el sistema para que al modificar datos estos puedan ser publicados en redis en formato de entidad (JSON).

El framework StackExchange trae un metodo que consigue la publicacion de la siguiente forma.

```csharp
GetSubscriber()           //para obtener el sub o pub.
Publish(channel, message) //para enviar el mensaje
Subscribe(new RedisChannel("Channel / PatronDeChannel", RedisChannel.PatternMode.Auto));
```

Ejemplo: 
```csharp
  public void Set(string Key, string Value)
        {
            redis.HashSet(Key, "Datos", Value);
            redis.Multiplexer.GetSubscriber().Publish(Key, Value);           
        }
```

### Dependencias 🔧
---

- StackExchange: Conexion con redis en C#
- Swagger: testing de la API 

### API 🔧
---
La API cuenta con 3 acciones basica, agregado de registros, modificacion de registros y obtencion de registros.
A la hora de enviar realizar un alta o modificacion de un registro en REDIS, el sistema esta diseñado para recibir una KEY y una value en formato JSON.

## Autor🤓
---
Omar Musmanno


## Información adicional📄
---
[Documentacion de REDIS](https://redis.io/documentation)

[Documentacion de Master-Slave](https://enmilocalfunciona.io/configuracion-basica-de-un-cluster-redis-sentinel-bajo-unix/)
