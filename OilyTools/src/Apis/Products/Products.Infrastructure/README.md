## Infrastructure Layer

This layer contains classes for accessing external resources such as databases, file systems, web services, and so on. Should contain the DbContexts, migrations, and repositories for accessing the external resources. These classes should be based on interfaces defined within the application (core) layer.

## Dependencies within solution

This layer should only be dependent on the Core project of the Api.

```
+--------------------+
|{api}.Infrastructure|
+---------+----------+
          |
          v
     +----+-----+
     |{api}.Core|
     +----+-----+

```