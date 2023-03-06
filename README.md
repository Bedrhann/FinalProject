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
* **Global Exception Handler**
* **RabbitMQ ile Message Queue kullanımı**
* **Unit ve Entegrasyon Testleri**

## Mimari
* **Onion Architecture** => Proje Clean Architecutre prensiplerine uygun olacak şekilde bir mimari ile tasarlanmıştır.
![image](https://user-images.githubusercontent.com/99317183/223220886-023176c1-4c13-4a49-944f-fb5d015bf826.png)


## Dosya Yapısı
* **Consumer** => RabbitMq'da gerekli kuyruğu dinleyerek gelen verileri MongoDb'ye işleyen yapı.
* **Core**
* **Mapster**
* **Mapster**
* **Mapster**
* **Mapster**

![image](https://user-images.githubusercontent.com/99317183/223219920-81ebe89b-aeb2-461f-83e2-8038edf3d83e.png)


![image](https://user-images.githubusercontent.com/99317183/223213316-f90d16c6-cef1-4f3d-8a9f-302aff525fee.png)
