## 1. The request journey

```
Client (Postman, browser)
    | JSON: a DTO
    V
Controller (speaks HTTP, reads the request, picks the status code)
    | DTO
    V
Services (The rules / logic, converts DTO to entities and back)
    | Entity
    V
Repository (The only layer that talks to the database)
    | Entity
    V
DbContext (Ef Core)
    | SQL
    V
Database
```