#!/bin/bash

cp /usr/local/sbin/api.skinet.dotnet.service /etc/systemd/system/

systemctl daemon-reload
systemctl enable api.skinet.dotnet.service
systemctl start api.skinet.dotnet.service
