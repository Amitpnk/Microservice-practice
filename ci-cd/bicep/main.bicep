param location string = resourceGroup().location
param environment string = 'dev'
param projectName string = 'eventick'
param serviceBusSku string = 'Standard'

// Service Bus naming convention
var serviceBusName = 'sb-${projectName}-${environment}-001'

resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2022-10-01-preview' = {
  name: serviceBusName
  location: location
  sku: {
    name: serviceBusSku
    tier: serviceBusSku
  }
  properties: {}
  tags: {
    Project: projectName
    Environment: environment
    Deployment: 'Bicep'
  }
}

// Common topic properties
var topicProperties = {
  defaultMessageTimeToLive: 'P14D' // 14 days retention
  enableDuplicateDetection: true
  duplicateDetectionHistoryTimeWindow: 'PT10M' // 10-minute detection window
  enablePartitioning: false
  maxSizeInMegabytes: 1024
}

resource checkoutTopic 'Microsoft.ServiceBus/namespaces/topics@2022-10-01-preview' = {
  parent: serviceBusNamespace
  name: 'checkoutmessage'
  properties: topicProperties
}

resource orderPaymentRequestTopic 'Microsoft.ServiceBus/namespaces/topics@2022-10-01-preview' = {
  parent: serviceBusNamespace
  name: 'orderpaymentrequestmessage'
  properties: topicProperties
}

resource orderPaymentUpdatedTopic 'Microsoft.ServiceBus/namespaces/topics@2022-10-01-preview' = {
  parent: serviceBusNamespace
  name: 'orderpaymentupdatedmessage'
  properties: topicProperties
}

// Output connection string for applications to use
output primaryConnectionString string = listKeys(serviceBusNamespace.id + '/authorizationRules/RootManageSharedAccessKey', serviceBusNamespace.apiVersion).primaryConnectionString
output serviceBusName string = serviceBusName