# 🏨 Deluxe Hotel Project 🚀

<div align="center">

  ![Logo](https://img.shields.io/badge/HOTEL-DELUXE-gold?style=for-the-badge&logo=hotel&logoColor=black)
  
  **Yapay Zeka Destekli, Modern ve Modüler Otel Yönetim Sistemi**

  <p>
    <a href="#-teknolojiler">
      <img src="https://img.shields.io/badge/.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET Core" />
    </a>
    <a href="#-teknolojiler">
      <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white" alt="C#" />
    </a>
    <a href="#-yapay-zeka">
      <img src="https://img.shields.io/badge/Google%20Gemini%20AI-8E75B2?style=flat-square&logo=googlebard&logoColor=white" alt="Gemini AI" />
    </a>
    <a href="#-lisans">
      <img src="https://img.shields.io/badge/Lisans-MIT-blue?style=flat-square" alt="License" />
    </a>
    <a href="#">
      <img src="https://img.shields.io/badge/Durum-Geliştiriliyor-orange?style=flat-square" alt="Status" />
    </a>
  </p>

  [Proje Hakkında](#-proje-hakkında) • [Özellikler](#-özellikler) • [Kurulum](#-kurulum) • [İletişim](#-iletişim)

</div>

---

## 📖 Proje Hakkında

**Deluxe Hotel Project**, klasik otel rezervasyon sistemlerinin ötesine geçen, **ASP.NET Core MVC** mimarisi üzerine inşa edilmiş kapsamlı bir web uygulamasıdır. 

Sadece CRUD işlemleri yapmakla kalmaz; **Google Gemini AI** entegrasyonu sayesinde akıllı içerik üretir, dış API'ler (Hava Durumu, Finans) ile anlık veri akışı sağlar ve **ViewComponent** mimarisi ile yüksek performanslı, modüler bir deneyim sunar.

---

## 📸 Ekran Görüntüleri

<div align="center">
 <img width="1915" height="994" alt="Image" src="https://github.com/user-attachments/assets/0cba816f-3fe3-4ba4-9ccf-305df233a9c7" />
  <br><br>
<img width="1904" height="996" alt="Image" src="https://github.com/user-attachments/assets/e798089a-8463-4823-ac62-68b66cb377a6" />

<img width="1900" height="993" alt="Image" src="https://github.com/user-attachments/assets/5bb63e9f-ad5f-479a-a26f-cce65ed86fcf" />

<img width="1909" height="995" alt="Image" src="https://github.com/user-attachments/assets/67f59a49-394e-4793-aa43-aac9bd165f9c" />

<img width="1902" height="994" alt="Image" src="https://github.com/user-attachments/assets/12d2d59b-f1cb-4138-9374-8dcbc44dcf7c" />

<img width="1904" height="994" alt="Image" src="https://github.com/user-attachments/assets/fc7e1d45-c4f1-4c80-84f8-7abc278c21bb" />
</div>

---

## ✨ Özellikler

### 🤖 Yapay Zeka Entegrasyonu (Gemini AI)
Proje, Google'ın üretken yapay zekası **Gemini** ile güçlendirilmiştir.
- **Akıllı İçerik:** Otel açıklamaları ve blog yazıları AI tarafından optimize edilir.
- **Dinamik Yanıtlar:** Kullanıcı etkileşimlerinde yapay zeka destekli geri bildirimler.

### 🧩 Modüler Mimari & Teknik Derinlik
- **ViewComponents:** Dashboard, Navbar ve Widget'lar bağımsız bileşenler olarak tasarlandı (`_DashboardWeatherComponentPartial`, `_DashboardFinansComponentPartial`).
- **DTO Pattern:** Veri güvenliği ve performansı için Data Transfer Object (DTO) kullanımı.
- **Service-Oriented Architecture:** İş mantığı servis katmanlarına (`IApiService`, `IGeminiService`) ayrılmıştır.

### 🌐 Canlı Veri Akışı (3. Parti API'ler)
- **🌤 Hava Durumu:** RapidAPI üzerinden anlık hava durumu verileri.
- **💰 Finans & Borsa:** Canlı döviz ve coin piyasa takibi.
- **🎬 Etkinlik & Film:** Bölgedeki etkinlikler için veri çekimi.

---

## 🛠 Teknolojiler

Bu projede kullanılan teknoloji yığını ve kütüphaneler:

| Alan | Teknoloji | Açıklama |
| :--- | :--- | :--- |
| **Backend** | ![.NET](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white) | Güçlü ve ölçeklenebilir altyapı |
| **Dil** | ![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white) | Modern C# özellikleri |
| **AI** | ![Gemini](https://img.shields.io/badge/Google%20Gemini-4285F4?style=flat-square&logo=google&logoColor=white) | Generative AI Servisi |
| **Frontend** | ![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=flat-square&logo=bootstrap&logoColor=white) | Responsive tasarım |
| **API** | ![REST](https://img.shields.io/badge/REST%20API-005571?style=flat-square&logo=postman&logoColor=white) | JSON tabanlı veri iletişimi |

---

## 📂 Proje Yapısı

Projenin temel klasör yapısı ve modülleri:

```bash
DeluxeHotelProject
├── 📂 Controllers        # MVC Controller'lar (Dashboard, Home, Default)
├── 📂 DTOs               # Veri Transfer Nesneleri (FilmDto, FinanceDto, WeatherDto)
├── 📂 Models             # Veritabanı Entity Modelleri
├── 📂 Services           # İş Mantığı Katmanı
│   ├── 📜 GeminiService  # Google AI Entegrasyon Kodları
│   └── 📜 ApiService     # Dış API Tüketim Servisleri
├── 📂 ViewComponents     # Tekrar kullanılabilir UI Bileşenleri
└── 📂 Views              # Razor Sayfaları
