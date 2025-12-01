# A2.SBO.SDK

**SAP Business One (SBO) entegrasyonu için .NET 8 backend çözümü ve Mock Service Layer.**

---

## 🟢 Solution Yapısı

A2.SBO.SDK/
│
├── MockServiceLayer/ # Test amaçlı sahte SAP Service Layer API
│ ├── Controllers/
│ │ ├── LoginController.cs
│ │ ├── BusinessPartnersController.cs
│ │ └── OrdersController.cs
│ └── Program.cs
│
└── SapIntegrationApi/ # Mock veya gerçek SAP’a bağlanan backend
├── Controllers/
│ ├── CustomersController.cs
│ └── OrdersController.cs
├── Services/
│ └── SapServiceLayerClient.cs
├── DTOs/
│ ├── CustomerDto.cs
│ └── OrderDto.cs
└── Program.cs


---

## 🟢 Özellikler

- **MockServiceLayer**
  - SAP Service Layer endpointlerini taklit eder
  - `/b1s/v1/Login` → sahte session ID döner
  - `/b1s/v1/BusinessPartners` → sahte müşteri ekleme / listeleme
  - `/b1s/v1/Orders` → sahte sipariş ekleme / listeleme

- **SapIntegrationApi**
  - Mock veya gerçek SAP SL’e bağlanır
  - DTO kullanarak veri taşır
  - Service sınıfı SAP etkileşimini yönetir
  - Controller’lar HTTP endpointlerini sunar

- **CORS** frontend testi için etkin
- **Swagger** UI ile endpoint testleri yapılabilir
- Temiz, sürdürülebilir ve ölçeklenebilir mimari
