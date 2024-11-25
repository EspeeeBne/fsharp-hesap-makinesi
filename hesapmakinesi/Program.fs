open System
open System.Collections.Generic

let rec getValidDoubleInput () =
    let mutable isValid = false
    let mutable value = 0.0
    while not isValid do
        let input = Console.ReadLine()
        match System.Double.TryParse(input) with
        | true, v ->
            value <- v
            isValid <- true
        | _ -> printf "Hata: Geçerli bir sayı girin: "
    value

let rec mainLoop (devam: bool) (islemGecmisi: List<string>) =
    if devam then
        printfn "Hesap Makinesi\n"
        printfn "Yapmak istediğiniz işlemi seçin:"
        printfn "1. Toplama"
        printfn "2. Çıkarma"
        printfn "3. Çarpma"
        printfn "4. Bölme"
        printfn "5. Üs Alma"
        printfn "6. Karekök Alma"
        printfn "7. Ortalama Hesaplama"
        printfn "8. Faktoriyel Hesaplama"
        printfn "9. Geçmiş İşlemleri Görüntüle"
        printfn "Çıkmak için q'ya basın\n"
        printf "Seçiminizi yapın: "
        let secim = Console.ReadLine()

        match secim with
        | "q" ->
            printfn "Programdan çıkılıyor. Görüşürüz!"
        | "1" ->
            printf "Birinci sayıyı girin: "
            let sayi1 = getValidDoubleInput()
            printf "İkinci sayıyı girin: "
            let sayi2 = getValidDoubleInput()
            let sonuc = sayi1 + sayi2
            islemGecmisi.Add(sprintf "%f + %f = %f" sayi1 sayi2 sonuc)
            printfn "Sonuç: %f\n" sonuc
            mainLoop true islemGecmisi
        | "2" ->
            printf "Birinci sayıyı girin: "
            let sayi1 = getValidDoubleInput()
            printf "İkinci sayıyı girin: "
            let sayi2 = getValidDoubleInput()
            let sonuc = sayi1 - sayi2
            islemGecmisi.Add(sprintf "%f - %f = %f" sayi1 sayi2 sonuc)
            printfn "Sonuç: %f\n" sonuc
            mainLoop true islemGecmisi
        | "3" ->
            printf "Birinci sayıyı girin: "
            let sayi1 = getValidDoubleInput()
            printf "İkinci sayıyı girin: "
            let sayi2 = getValidDoubleInput()
            let sonuc = sayi1 * sayi2
            islemGecmisi.Add(sprintf "%f * %f = %f" sayi1 sayi2 sonuc)
            printfn "Sonuç: %f\n" sonuc
            mainLoop true islemGecmisi
        | "4" ->
            printf "Birinci sayıyı girin: "
            let sayi1 = getValidDoubleInput()
            printf "İkinci sayıyı girin: "
            let sayi2 = getValidDoubleInput()
            if sayi2 <> 0.0 then
                let sonuc = sayi1 / sayi2
                islemGecmisi.Add(sprintf "%f / %f = %f" sayi1 sayi2 sonuc)
                printfn "Sonuç: %f\n" sonuc
            else
                printfn "Hata: Bir sayı sıfıra bölünemez.\n"
            mainLoop true islemGecmisi
        | "5" ->
            printf "Taban sayıyı girin: "
            let sayi1 = getValidDoubleInput()
            printf "Üs değerini girin: "
            let us = getValidDoubleInput()
            let sonuc = Math.Pow(sayi1, us)
            islemGecmisi.Add(sprintf "%f ^ %f = %f" sayi1 us sonuc)
            printfn "Sonuç: %f\n" sonuc
            mainLoop true islemGecmisi
        | "6" ->
            printf "Sayıyı girin: "
            let sayi1 = getValidDoubleInput()
            if sayi1 >= 0.0 then
                let sonuc = Math.Sqrt(sayi1)
                islemGecmisi.Add(sprintf "√%f = %f" sayi1 sonuc)
                printfn "Sonuç: %f\n" sonuc
            else
                printfn "Hata: Negatif bir sayının karekökü alınamaz.\n"
            mainLoop true islemGecmisi
        | "7" ->
            printf "Kaç sayı gireceksiniz?: "
            let adet = int (getValidDoubleInput())
            let mutable toplam = 0.0
            for i in 1..adet do
                printf "%d. sayıyı girin: " i
                toplam <- toplam + getValidDoubleInput()
            let sonuc = toplam / float adet
            islemGecmisi.Add(sprintf "Girilen %d sayının ortalaması = %f" adet sonuc)
            printfn "Sonuç: %f\n" sonuc
            mainLoop true islemGecmisi
        | "8" ->
            printf "Faktoriyelini almak istediğiniz sayıyı girin: "
            let faktoriyelSayisi = int (getValidDoubleInput())
            let mutable sonuc = 1.0
            for i in 1..faktoriyelSayisi do
                sonuc <- sonuc * float i
            islemGecmisi.Add(sprintf "%d! = %f" faktoriyelSayisi sonuc)
            printfn "Sonuç: %f\n" sonuc
            mainLoop true islemGecmisi
        | "9" ->
            printfn "Geçmiş İşlemler:"
            islemGecmisi |> Seq.iter (printfn "%s")
            mainLoop true islemGecmisi
        | _ ->
            printfn "Geçersiz seçim. Lütfen 1-9 arasında bir seçim yapın.\n"
            mainLoop true islemGecmisi
    else
        ()

[<EntryPoint>]
let main argv =
    let islemGecmisi = new List<string>()
    mainLoop true islemGecmisi
    0
