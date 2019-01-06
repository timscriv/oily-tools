## Api Core Layer

This layer is the center of the architecture and is where the apis' domain work should be done. This layer should contain things like:

- Domain Events (for "side-effects" of the system)
- Entities (for representing business objects)
- Exceptions (to throw meaningful errors)
- Event Handlers (for doing the work of a domain event)
- Interfaces (including interfaces for infrastructure project to implement)
- UseCases (for encapsulating and implementing all the use cases of the system, entry-point of the core layer)
- Services (fine-grained workers that can be called by a use case)

## Dependencies within solution

This layer should only be dependent on the Core project of the Api.

```
  +----------+
  |{api}.Core|
  +----+-----+
       |
       v
+------+------+
|{shared}.Core|
+-------------+
```