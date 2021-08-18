# MyStore 是 ASPNET MVC安全程式開發的 Lab 練習方案

## 目標

透過線上購物網站來讓學員可以透過實際操作來體驗 OWASP Top 10 - 2017 各項資安問題。
攻擊練習後並加以修正。

## 各專案說明

|專案|說明|
|---|---|
|Attacker.MyStore|惡意的網站 (<http://localhost:53441>)|
|EmailReader|讀取 eml 程式(如果本機無法看 eml 內容，可透過此程式讀取)|
|EncodeTools|UrlEncode/Decode/Base64 Encode/Base64 Decode程式|
|Guessing|SQL Injection Help 程式|
|KeyLogger|從 Github 取得的 Keylogger 程式|
|MyStore.Domain|MyStore.WebUI參考使用的Domain專案|
|MyStore.WebUI|線上購物網站 (<http://localhost:44375>)|
|OrderApp|訂單的WebService (<http://localhost:50480>)|
|PasswordDictionaryAttack|密碼字典破解的 Console 程式|
|XXEDemo|透過 XMLDocument 來讀取 C:\Windows\Win.ini 內容的 Console 程式|

## 環境

* Windows 10
* Visual Studio 2017/2019/2022(安裝時請勾選 SQL Server Express 20xx LocalDB)
* ASP.NET MVC (.NET Framework 4.5)
