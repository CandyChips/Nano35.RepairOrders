# Nano35.RepairOrders

    docker build -t bushemi2021/nano35.repair-orders.api:latest ./Nano35.RepairOrders.Api
    docker push bushemi2021/nano35.repair-orders.api:latest
    docker build -t bushemi2021/nano35.repair-orders.processor:latest ./Nano35.RepairOrders.Processor
    docker push bushemi2021/nano35.repair-orders.processor:latest
