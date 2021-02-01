# Nano35.RepairOrders

## Access

### Api access on local adress http://192.168.100.210:30101

## Push new version

### of Nano35.RepairOrders.Api

    docker build -t bushemi2021/nano35.repairorders.api:latest ./Nano35.RepairOrders.Api
    docker push bushemi2021/nano35.repairorders.api:latest

### of Nano35.RepairOrders.Processor

    docker build -t bushemi2021/nano35.repairorders.processor:latest ./Nano35.RepairOrders.Processor
    docker push bushemi2021/nano35.repairorders.processor:latest

### then restart deployment instance
