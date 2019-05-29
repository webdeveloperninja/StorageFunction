# StorageFunction
 
 Add the following variables
 ```
  "Access_Key": "{{ Your Storage Access Key }}",
  "Account_Name": "{{ Your Storage Account Name}}"
  ```
  
  
Post to endpoint with following body content
```
{
  "ContentType": "{{ Your Content Type }}",
  "ContainerName": "{{ Your Storage Container Name }}",
  "Base64Data": "{{ Your data converted to Base64 }}"
}
```
