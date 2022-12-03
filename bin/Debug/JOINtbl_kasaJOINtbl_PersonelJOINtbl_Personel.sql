SELECT 
tbl_kasa.KID AS tbl_kasaKID
,tbl_kasa.CarPlaka AS tbl_kasaCarPlaka
,tbl_kasa.Ucret AS tbl_kasaUcret
,tbl_cars.AID AS tbl_carsAID
,tbl_cars.AdSoyad AS tbl_carsAdSoyad
,tbl_cars.Plaka AS tbl_carsPlaka
,tbl_cars.GirisZamani AS tbl_carsGirisZamani
,tbl_cars.Marka AS tbl_carsMarka
,tbl_cars.Model AS tbl_carsModel
,tbl_cars.Renk AS tbl_carsRenk
,tbl_cars.YakitTuru AS tbl_carsYakitTuru
,tbl_cars.SaatGun AS tbl_carsSaatGun
,tbl_cars.Vale AS tbl_carsVale
,tbl_cars.Yikama AS tbl_carsYikama
,tbl_cars.AcikKapali AS tbl_carsAcikKapali
,tbl_kasa.KID AS tbl_kasaKID
,tbl_kasa.CarPlaka AS tbl_kasaCarPlaka
,tbl_kasa.Ucret AS tbl_kasaUcret
,tbl_Personel.PID AS tbl_PersonelPID
,tbl_Personel.PTC AS tbl_PersonelPTC
,tbl_Personel.PAdSoyad AS tbl_PersonelPAdSoyad
,tbl_Personel.PAlan AS tbl_PersonelPAlan
,tbl_Personel.PCalismaSaati AS tbl_PersonelPCalismaSaati
,tbl_Personel.PUcret AS tbl_PersonelPUcret
,tbl_Personel.PID AS tbl_carsPID
,tbl_Personel.PTC AS tbl_carsPTC
,tbl_Personel.PAdSoyad AS tbl_carsPAdSoyad
,tbl_Personel.PAlan AS tbl_carsPAlan
,tbl_Personel.PCalismaSaati AS tbl_carsPCalismaSaati
,tbl_Personel.PUcret AS tbl_carsPUcret
 FROM tbl_kasa
 JOIN tbl_cars
 ON tbl_kasa.Ucret=tbl_cars.Marka
 JOIN tbl_kasa
 ON tbl_cars.Marka=tbl_kasa.CarPlaka
 JOIN tbl_Personel
 ON tbl_kasa.CarPlaka=tbl_Personel.PCalismaSaati
 JOIN tbl_Personel
 ON tbl_Personel.PCalismaSaati=tbl_Personel.PAlan