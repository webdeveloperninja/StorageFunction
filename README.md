# StorageFunction
 
 Add the following variables to your `local.settings.json` or enviroment variables
 ```
  "Access_Key": "{{ Your Storage Access Key }}",
  "Account_Name": "{{ Your Storage Account Name}}"
  ```
  
  
Post to endpoint with following body content
`/api/Storage`
```
{
  "ContentType": "{{ Your Content Type }}",
  "ContainerName": "{{ Your Storage Container Name }}",
  "Base64Data": "{{ Your data converted to Base64 }}"
}
```
