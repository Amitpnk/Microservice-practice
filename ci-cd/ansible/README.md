winget install -e --id Microsoft.AzureCLI

pip install ansible


pip install -r "$env:USERPROFILE\.ansible\collections\ansible_collections\azure\azcollection\requirements-azure.txt"


pip install pywin32


ansible --version


ansible-doc -t module azure_rm_servicebus