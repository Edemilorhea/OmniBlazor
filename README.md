# LoginAPI

# .Net 8 Blazor WebAssembly

帶有前端套件庫 Blazorise 使用。

實現功能:
- Login
- Logout
  - 帶有JWT Header 發送 進行登出及 記錄進後台JWT黑名單內 
- register

未實現項目:
- Profile 個人資料呈現。

appsettings.json 設定如下
- 對應的是後端登入系統站台端點。
- 需放入 OmniBlazor\wwwroot 資料夾內
```
{
    "ApiEndpoint": {
        "LoginApi": "http://hostname:port/"
    }
}

```

## 頁面說明
站台啟動後右上角有下拉選單可註冊及登入，並帶有前端表單驗證、登入後驗證通過成為可看到Profile與進入Profile頁面的驗證，登出後重新刷新頁面，將JWT註銷並且加入後台黑名單。
