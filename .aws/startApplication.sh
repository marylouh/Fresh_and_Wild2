#!/bin/bash
# to remove once you set bash_profile correctly
export DOTNET_ROOT=/tmp/dotnet
export PATH=$PATH:$DOTNET_ROOT
cd /var/www/my-temp-dir/
echo "dotnet ChoixResto.dll > /dev/null 2>&1 &"
dotnet ChoixResto.dll > /dev/null 2>&1 &
# cd  /var/www/my-temp-dir/
# rm -rf *