#!bin/bash

for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -d master -i /database/init.sql
    if [ $? -eq 0 ]
    then
        echo "init.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done