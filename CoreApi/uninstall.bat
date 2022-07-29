set serviceName=MzghApi

sc stop   %serviceName%
sc delete %serviceName%

pause