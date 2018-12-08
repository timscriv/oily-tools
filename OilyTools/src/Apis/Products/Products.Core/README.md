## Api Core Layer

This layer is the center of the architecture and is where the apis' domain work should be done. This layer should contain things like:

- Converters (for mapping between object types i.e. DTO to entity)
- Domain Events (for "side-effects" of the system)
- DTOs (for presenting outside of domain)
- Entities (for representing business objects)
- Exceptions
- Event Handlers (for doing the work of a domain event)
- Services (For doing the CRUD work of the system)
- UseCases (for encapsulating and implementing all the use cases of the system)

## Dependencies within solution

This layer should only be dependent on the Core project of the Api.

```
     +----+-----+
     |{api}.Core|
     +----+-----+
          |
          v
   +-------------+
   |{shared}.Core|
   +------+------+

```