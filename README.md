# Step1 - Ürün Yönetim API Projesi

Bu proje, .NET 8 ve Entity Framework Core kullanılarak geliştirilmiş bir ürün yönetim API'sidir. Katmanlı mimari ile geliştirilmiş olup, ürünlerin listelenmesi, eklenmesi, güncellenmesi ve silinmesi gibi temel CRUD işlemlerini destekler.

## Proje Yapısı

- **EntityLayer**: Veri modelleri ve DTO'lar.
- **DataAccessLayer**: Entity Framework Core ile veri erişim katmanı ve generic repository.
- **BusinessLayer**: Servisler, iş mantığı ve mapping işlemleri.
- **WepAPI**: API katmanı, controller ve middleware.

## Özellikler

- Ürün ekleme, silme, güncelleme, detay görüntüleme.
- Sayfalama ile ürün listeleme.
- Swagger/OpenAPI desteği.
- Global hata yönetimi.
- Docker ile containerize edilebilir yapı.

## Kurulum ve Çalıştırma

1. **Bağımlılıkları yükleyin:**
   ```
   dotnet restore
   ```

2. **Veritabanı bağlantısını ayarlayın:**
   - [`WepAPI/appsettings.json`](WepAPI/appsettings.json) dosyasındaki `DefaultConnection` bağlantı cümlesini kendi veritabanınıza göre düzenleyin.

3. **Veritabanı migrasyonlarını uygulayın:**
   ```
   dotnet ef database update --project DataAccessLayer
   ```

4. **Projeyi başlatın:**
   ```
   dotnet run --project WepAPI
   ```

5. **Swagger arayüzüne erişin:**
   - [http://localhost:5095/swagger](http://localhost:5095/swagger)

## API Endpointleri

- `POST /api/Product` : Ürün ekler.
- `GET /api/Product` : Sayfalama ile ürünleri listeler.
- `GET /api/Product/{id}` : Ürün detayını getirir.
- `PUT /api/Product/{id}` : Ürünü günceller.
- `DELETE /api/Product?id={id}` : Ürünü siler.

## Docker ile Çalıştırma

1. **Docker imajı oluşturun:**
   ```
   docker build -t step1-api -f WepAPI/Dockerfile .
   ```

2. **Container başlatın:**
   ```
   docker run -p 8080:8080 step1-api
   ```
