#
# DockerInstances.ps1
#

docker run  -d   --restart unless-stopped   --name seqlogserver   -e ACCEPT_EULA=Y   -v seqlog:/data  -p 82:80  -p 5341:5341 datalust/seq:latest
