# PARAM Practicum FinalProject / SBasket API

## Proje İçeriği
* **.Net 6 ile geliştirilen bir Restful API** 
* **Kullanıcılar tarafından kontrol edilebilen bir Alışveriş Listesi oluşturulur.**
* **Kullanıcılar kayıt ve giriş yapabilirler. Ardından, listeleri ve liste öğelerini ekleyebilir, güncelleyebilir, silebilir veya arayabilirler.**
* **Listelerin altlarında kategoriler oluşturulur ve öğeler bu kategorilerin altlarına eklenir.**
* **Yönetici tüm listeleri, tamamlanan listelerin arşivini ve kullanıcı listesini görebilir.**
* **Normal işlemler için MsSql, Rabbitmq mesaj kuyruğu hizmeti tarafından gönderilen listeleri arşivlemek için MongoDB kullanılır.**

## Projede Kullanılanlar
* **.NET 6** 
* **Onion Architecture**
* **Repository Pattern**
* **Entity Framework**
* **CQRS yapısı ve Mediatr kütüphanesi**
* **Dependency Injection**
* **Jwt Token ile giriş yapma ve rolleme işlemleri**
* **Mapster**
* **MongoDb**
* **SeriLog**
* **Redis / Distributed Cache**
* **Response Cache**
* **Docker**
* **Global Exception Handler**
* **RabbitMQ ile Message Queue kullanımı**
* **Unit ve Entegrasyon Testleri**

## Mimari
* **Onion Architecture** => Proje Clean Architecture prensiplerine uygun olacak şekilde bir mimari ile tasarlanmıştır.

![image](https://user-images.githubusercontent.com/99317183/223220886-023176c1-4c13-4a49-944f-fb5d015bf826.png)


## Dosya Yapısı Ve Katmanlar

* **Domain** => Uygulamanın temel varlıklarını(Entities) içeren dışarı herhangi bir bağımlılığı olmayan katman.
* **Application** => Uygulama Arayüzlerini(Interfaces), Servisleri(CQRS) ve Dto nesnelerini içeren, projenin soyutlama ve yönlendirme katmanıdır.
* **Infrastructure** => Projenin sabit varlıkları ile direkt ilişkisi olmayan dış servislerin kullanımının yapıldığı katmandır.
* **Persistance** => Application katmanında yapılan soyutlamaların somut varlıklarının bulunduğu, sistemin iş yükünü barındıran katmandır.
* **Presentation** => Projenin yönetildiği, controller sınıflarının bulunduğu katmandır.
* **Test** => Projenin Unit ve Entegrasyon testlerinin bulunduğu katman.
* **Consumer** => RabbitMq'da gerekli kuyruğu dinleyerek gelen verileri MongoDb'ye işleyen katman.
* 
![image](https://user-images.githubusercontent.com/99317183/223219920-81ebe89b-aeb2-461f-83e2-8038edf3d83e.png)

## Veri Tabanı

* **MsSql** => projede kullanılan ana veritabanıdır, ilişkisel şekilde kuralan yapının şeması;

![image](https://user-images.githubusercontent.com/99317183/223213316-f90d16c6-cef1-4f3d-8a9f-302aff525fee.png)


## Log
* Projenin logları SeriLog kütüphanesi kullanılarak bir text dosyasına günlük olarak yazılmaktadır.

![image](https://user-images.githubusercontent.com/99317183/223226141-087f6760-4304-4286-b26c-05482f1df75c.png)


## Test
* 2 adet unit test bulunmaktadır 
** 1- Categorinin eklenme endpoint'i 
** 2-  Ürünlerin  eklenme endpoint'i 

