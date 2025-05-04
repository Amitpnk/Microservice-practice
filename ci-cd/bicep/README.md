- Check Bicep Version
```
az bicep version
```

- Install Bicep
```
az bicep install
```
- upgrade (If already installed)
```
az bicep upgrade
```

- Get valid apiversion
```
az provider show --namespace Microsoft.Resources --query "resourceTypes[?resourceType=='resourceGroups'].apiVersions" -o tsv
```

```
az deployment group create \
  --resource-group rg-eventick-dev-001 \
  --template-file main.bicep \
  --parameters environment=dev projectName=eventick 
```


az deployment group create ^
  --resource-group rg-eventick-dev-001 ^
  --template-file main.bicep ^
  --parameters environment=dev projectName=eventick 


az deployment group create --resource-group rg-eventick-dev-001 --template-file eventick.bicep --parameters environment=dev projectName=eventick 
