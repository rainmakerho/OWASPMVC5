# A4: XML External Entities (XXE)

## 目標

>透過載入 XML 文件來取得 C:\Windows\Win.ini 的檔案內容

## 練習步驟

1. 開啟**XXEDemo**專案中的 **XmlDemo.xml** 檔案。XML中的 Entity name 指向 C:\Windows\Win.ini 的檔案，當 .NET 版本為 4.5.1(含) 之前版本，會啟用 DTD 解析，所以執行程式後，會將 C:\Windows\Win.ini 的內容讀取出來。

    ```xml
    <?xml version="1.0"?>
    <!DOCTYPE order[
        <!ENTITY name SYSTEM 'C:\WINDOWS\WIN.INI'>
    ]>
    <order>
        <order_id>5e82da5d47ff063da0d6c3b5</order_id>
        <email>&name;</email>
    </order>
    ```

>修正
>
>1.請參考 todo: Session-6.2
>
>2.修改專案 .NET 4.5.1 以上版本建置後，再執行一次

[Back](./../../readme.md)
