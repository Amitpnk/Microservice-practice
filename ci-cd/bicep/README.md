- Check Bicep Version
```
az bicep version
```

- Install Bicep
```
az bicep install
```


```
az deployment group create \
  --resource-group rg-eventick-dev-001 \
  --template-file main.bicep \
  --parameters environment=dev projectName=eventick 
```