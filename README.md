# PARAM Practicum FinalProject / SBasket API

## Proje İçeriği
* **.Net 6 ile geliştirilen bir Restful API** 
* **Kullanıcılar tarafından kontrol edilebilen bir Alışveriş Listesi oluşturulur.**
* **Kullanıcılar kayıt ve giriş yapabilirler. Ardından, listeleri ve liste öğelerini ekleyebilir, güncelleyebilir, silebilir veya arayabilirler.**
* **Listelerin altlarında kategoriler oluşturulur ve öğeler bu kategorilerin altlarına eklenir.**
* **Yönetici tüm listeleri, tamamlanan listelerin arşivini ve kullanıcı listesini görebilir.**
* **Normal işlemler için MsSql, Rabbitmq mesaj kuyruğu hizmeti tarafından gönderilen listeleri arşivlemek için MongoDB kullanılır.**

## Projede Kullanılanlar
:heavy_check_mark: **.NET 6**<br>
:heavy_check_mark: **Onion Architecture**<br>
:heavy_check_mark: **Repository Pattern**<br>
:heavy_check_mark: **Entity Framework**<br>
:heavy_check_mark: **CQRS yapısı ve Mediatr kütüphanesi**<br>
:heavy_check_mark: **Dependency Injection**<br>
:heavy_check_mark: **Jwt Token ile giriş yapma ve rolleme işlemleri**<br>
:heavy_check_mark: **Mapster**<br>
:heavy_check_mark: **MongoDb**<br>
:heavy_check_mark: **MsSql**<br>
:heavy_check_mark: **SeriLog**<br>
:heavy_check_mark: **Fluent Validation**<br>
:heavy_check_mark: **Redis / Distributed Cache**<br>
:heavy_check_mark: **Response Cache**<br>
:heavy_check_mark: **Docker**<br>
:heavy_check_mark: **Paging**<br>
:heavy_check_mark: **Global Exception Handler**<br>
:heavy_check_mark: **RabbitMQ ile Message Queue kullanımı**<br>
:heavy_check_mark: **Unit ve Entegrasyon Testleri**<br>

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

![image](https://user-images.githubusercontent.com/99317183/223219920-81ebe89b-aeb2-461f-83e2-8038edf3d83e.png)

## Veri Tabanı

* **MsSql** => projede kullanılan ana veritabanıdır, ilişkisel şekilde kuralan yapının şeması;

![image](https://user-images.githubusercontent.com/99317183/223213316-f90d16c6-cef1-4f3d-8a9f-302aff525fee.png)


## Log
* **Projenin logları SeriLog kütüphanesi kullanılarak bir text dosyasına günlük olarak yazılmaktadır.**

![image](https://user-images.githubusercontent.com/99317183/223226141-087f6760-4304-4286-b26c-05482f1df75c.png)


## Test
* **2 adet unit test bulunmaktadır, Categori ve Ürünlerin eklenme endpoint'i**
* **2 adet Entegrasyon test bulunmaktadır, Kategori ve Ürünlerin işlemlerinin bulunduğu controller'ların örnek senaryo ile ekleme-listeleme-güncelleme-silme işlemleri test edilmektedir.**

![image](https://user-images.githubusercontent.com/99317183/223227611-5a4b2375-08b9-4b15-bc89-315ec533a726.png)


## Endpoint'ler

![image](https://user-images.githubusercontent.com/99317183/223228454-cd616d3f-bbb8-481a-a082-2ea3744a31fa.png)


## Örnek Senaryo 

* **Kullanıcı kayıt olur**

![1giris](https://user-images.githubusercontent.com/99317183/223238259-09799156-ceb9-4779-bfbf-af0f69ee1ff1.png)


* **Kullanıcı giriş yapar**

![2giris](https://user-images.githubusercontent.com/99317183/223238473-ea7ad9fd-5bd4-44a8-a179-20ea7b015817.png)


* **Kullanıcı liste oluşturur**

![3listekayıt](https://user-images.githubusercontent.com/99317183/223238919-ef213a0c-be7a-4985-873f-5f3d081ea66b.png)


* **Kullanıcı listeye kategori ekler**

![4kategorikayıt](https://user-images.githubusercontent.com/99317183/223239148-e7685c18-b4ed-43ab-ba26-fc5e6379a8d2.png)


* **Kullanıcı kategorinin altına ürün ekler**

![5ürünekle](https://user-images.githubusercontent.com/99317183/223239367-fa1a87d7-fe4e-4f7e-af45-a3f5a0499888.png)


* **Kullanıcı listelerini görüntüler**

![6listelisteme](https://user-images.githubusercontent.com/99317183/223239569-425d5eb5-e651-4ce9-a44a-c789bf798c71.png)


## Kurulum

- Projeyi indirmek için :
```
    git clone https://github.com/Bedrhann/FinalProject.git
```

- Veritabanı oluşturmak için package manager konsolunda default project kısmında `Persistence` seçili olmalıdır. Ardından :
```c
    update-database
```

- Appsettings.json içindeki bağlantı string'leri bilgisayardaki Mssql, Redis, MongoDb bağlantılarına göre ayarlanması gerekmektedir.
```c
  {
  "ConnectionStrings": {
    "MsSqlConnection": "Server=DESKTOP-415NNNG;Database=DB_SBasket;Trusted_Connection=True;",
    "Redis": "localhost:49153,password=redispw"
  },
  "MongoDb": {
    "ConnectionString": "mongodb://docker:mongopw@localhost:49153",
    "DatabaseName": "SBasketDb"
  },
```
- Docker kullanılıyor ise aşağıdaki gibi conteiner'ların ayakta olması gerekmektedir.

![image](https://user-images.githubusercontent.com/99317183/223229644-a8bf3a51-f767-4d71-bb0d-b32b2b5c1cd9.png)


