## Infrastructure Layer

This layer contains classes for accessing external resources such as databases, file systems, web services, and so on. These classes should be based on interfaces defined within the application (core) layer.

## Dependencies

This layer should only be dependent on the Core project of the Api.

```
+--------------------+
|{api}.Infrastructure|
+---------+----------+
          |
          v
     +----------+
     |{api}.Core|
     +----+-----+
          |
		  v
     +----------+
     |{sln}.Core|
     +----------+

```