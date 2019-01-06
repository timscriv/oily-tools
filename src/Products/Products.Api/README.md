# Api Layer

This layer is for exposing to the outside world. This layer should contain things like: 
- Converters (To change the Domain Models to DTOs and vice versa)
- Controllers (To define the API)
- DTOs (Simple POCOs that will be send over the wire)
- Exception Middleware (to convert from the domain exceptions to errors for the world, i.e. HttpStatusCode)

Being an API is just a detail, it could be swapped with a Console, WebUI, Azure Function, etc. 

## Dependencies within solution

This layer should be dependent on the Core project of the Api, and loosly dependent on the Infrastructure projects implementations (only used when registering the DI).

```
  +---------+       +--------------------+
  |{api}.Api|<------|{api}.Infrastructure|
  +----+----+       +---------+----------+
       |
       v
  +----+-----+
  |{api}.Core|
  +----+-----+
```