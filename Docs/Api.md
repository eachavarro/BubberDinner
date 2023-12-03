# BuberDinner API

-[Bubber Dinner API](#buberdinner-api)
    -[Auth](#auth)
        -[Register](#register)
            -[Register Request](#register-request)
            -[Register Response](#register-response)
        -[Login](#login)
            -[Login Request](#login-request)
            -[Login Response](#login-response)

##auth

###register

```js
{
    POST{{host}}/auth/register
}
```

#### Login Request
```json
{
    "email":"edgar.chavarro@test.com",
    "password":"eer.ER.%"
}
```

#### Login Response
```json
{
    "id":"",
    "firstName":"Edgar",
    "lastName":"Chavarro",
    "email":"",
    "token":"eer.ER.%"
}
```
