#!/bin/bash

cp api.skinet.service /etc/systemd/system/

systemctl daemon-reload;
systemctl enable api.skinet.dotnet.service;
systemctl start api.skinet.dotnet.service;
