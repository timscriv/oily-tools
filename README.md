## Architecture

Look at the readmes in the individual projects to get a better idea of what each of these should contain/do.

```
+-src-------------------------------------------------------------------------------------------------------------------+
|                                                                                                                       |
| +-Apis-------------------------------------------------------------------------------------------------------------+  |
| |                                                                                                                  |  |
| |  +-{api_1}--------------------------------------------+    +-{api_2}------------------------------------------+  |  |
| |  |                                                    |    |                                                  |  |  |
| |  |  +-----------+           +----------------------+  |    |  +-----------+         +----------------------+  |  |  |
| |  |  |{api_1}.Api|           |{api_1}.Infrastructure|  |    |  |{api_2}.Api|         |{api_2}.Infrastructure|  |  |  |
| |  |  +-----+-----+           +---------+------------+  |    |  +-----+-----+         +---------+------------+  |  |  |
| |  |         |                          |               |    |        |                         |               |  |  |
| |  |         |                          |               |    |        |                         |               |  |  |
| |  |         |    +------------+        |               |    |        |    +------------+       |               |  |  |
| |  |         +---->{api_1}.Core<--------+               |    |        +---->{api_2}.Core<-------+               |  |  |
| |  |              +-----+------+                        |    |             +-----+------+                       |  |  |
| |  |                    |                               |    |                   |                              |  |  |
| |  +--------------------|-------------------------------+    +-------------------|------------------------------+  |  |
| |                       |                                                        |                                 |  |
| +-----------------------|--------------------------------------------------------|---------------------------------+  |
|                         |                                                        |                                    |
|                         |                       +-------------+                  |                                    |
|                         +----------------------->{shared}.Core<------------------+                                    |
|                                                 +------+------+                                                       |
|                                                        |                                                              |
+--------------------------------------------------------|--------------------------------------------------------------+
                                                         |
                                              +----------v-----------+
                                              |external|kernal}.nupkg|
                                              +----------------------+
  
```

