#!/bin/sh
xrandr --output eDP --primary --right-of HDMI-A-0
xrandr --output HDMI-A-0 --set underscan on
xrandr --output HDMI-A-0 --auto --left-of eDP
xrandr --output HDMI-A-0 --set "underscan hborder" 60 --set "underscan vborder" 33
sleep 0.5
feh --bg-scale /home/mikairyuu/Documents/wallpaper
