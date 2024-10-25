# Meeting Organizer

## Kurulum Rehberi

### Ön Gereksinimler
- **.NET SDK**: Makinenizde .NET SDK'nın kurulu olduğundan emin olun. Bunu [resmi .NET web sitesinden](https://dotnet.microsoft.com/download) indirebilirsiniz.

- **SQL Server**: SQL Server'ın kurulu ve çalışır durumda olduğundan emin olun. Geliştirme için SQL Server Express kullanabilirsiniz.

- **IDE**: .NET geliştirme için Visual Studio veya tercih ettiğiniz başka bir IDE kullanın.

### Adım 1: Depoyu Klonlayın
Aşağıdaki komutu kullanarak depoyu yerel makinenize klonlayın:
```bash
git clone <depo-url>
```
`<depo-url>` kısmını gerçek depo URL'si ile değiştirin.

### Adım 2: Bağlantı Dizesini Yapılandırın
Projenin kök dizininde bulunan `appsettings.json` dosyasını açın ve bağlantı dizesini SQL Server örneğinize işaret edecek şekilde güncelleyin:
```json
"ConnectionStrings": {
    "SqlConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;"
}
```
`YOUR_SERVER_NAME`, `YOUR_DATABASE_NAME`, `YOUR_USERNAME` ve `YOUR_PASSWORD` kısımlarını SQL Server kimlik bilgilerinizle değiştirin.

### Adım 3: Veritabanı Göçü Oluşturun
Terminali veya Visual Studio'daki Paket Yöneticisi Konsolu'nu açın ve proje dizinine gidin. Veritabanı göçünü oluşturmak için aşağıdaki komutu çalıştırın:
```bash
dotnet ef migrations add InitialCreate
```

### Adım 4: Veritabanını Güncelleyin
Göç oluşturulduktan sonra veritabanını güncellemek için aşağıdaki komutu çalıştırın:
```bash
dotnet ef database update
```

### Adım 5: Uygulamayı Çalıştırın
Göç tamamlandıktan sonra uygulamayı çalıştırmak için aşağıdaki komutu kullanın:
```bash
dotnet run
```
Alternatif olarak, Visual Studio'dan doğrudan uygulamayı çalıştırmak için **F5** tuşuna basabilirsiniz.

### Adım 6: Uygulamaya Erişim
Web tarayıcınızı açın ve aşağıdaki adresi ziyaret edin:
```
https://localhost:5001
```
Bu, Meeting Organizer uygulamasının ana arayüzüne erişmenizi sağlayacaktır.

### Adım 7: Uygulamayı Kullanma
Uygulamaya eriştikten sonra, kullanıcı arayüzünü kullanarak toplantılar ve katılımcılar oluşturabilirsiniz.

### Ekran Görüntüleri
![UI Ekran Görüntüsü 1](https://github.com/user-attachments/assets/83f97ecb-e25f-4a0a-a752-38716f472744)
![UI Ekran Görüntüsü 2](https://github.com/user-attachments/assets/f77a6603-6889-473b-a883-80502246277f)
![UI Ekran Görüntüsü 3](https://github.com/user-attachments/assets/24a66e6f-66bf-46a6-80ef-6e76dddf1ae2)

**Not**: Bağlantı dizesi düzenlemesi yaptıktan sonra migration yaparak çalıştırabilirsiniz. Veri setleri oluşturulduktan sonra proje üzerinde işlemlerinizi gerçekleştirebilirsiniz.
