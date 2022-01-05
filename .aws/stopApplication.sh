#!/bin/bash
echo "stop application"
cd  /var/www/my-temp-dir/
echo "kill $(ps aux | grep ChoixResto.dll | awk '{print $2}')"
kill $(ps aux | grep ChoixResto.dll | awk '{print $2}') || echo "Process ChoixResto.dll was not running."
rm -rf /var/www/my-temp-dir/
