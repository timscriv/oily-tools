## Shared Core Layer

This layer contains the cross-cutting concerns across the entire solution. Should be kept very minimal and not include domain logic.

## Dependencies within solution

This layer should not have any dependencies within the solution, but could have a dependency on the SharedKernal of the enterprise (should be a nuget package).

```
     +-------------+
     |{shared}.Core|
     +------+------+
            |
            v
+-----------+-----------+
|{external-kernal}.nupkg|
+-----------------------+

```