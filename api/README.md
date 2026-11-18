## 1. The request journey

```
Client (Postman, browser)
    | JSON: a DTO
    V
Controller (speaks HTTP, reads the request, picks the status code)
    | DTO
    V
Services (The rules / logic, converts DTO to entities and back)
    | Entity/Model
    V
Repository (The only layer that talks to the database)
    | Entity/Model
    V
DbContext (Ef Core)
    | SQL
    V
Database
```

## 2. Recap of Day One

app.db we then created our models for our Database
AppDbContext (what allows our API to talk to our database)
We ran our migrations (Mapped our Models / Entities to our DB table)
We then made our Repository layer followed by our DTO

