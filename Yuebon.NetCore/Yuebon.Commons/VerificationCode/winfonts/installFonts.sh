#!/bin/bash
#创建字体目录
mkdir /usr/share/fonts/winfonts/
#拷贝字体
cp winFonts.tar.gz /usr/share/fonts/winfonts/
#解压字体
cd /usr/share/fonts/winfonts/
tar xf winFonts.tar.gz
#建立字体索引信息
mkfontscale
mkfontdir
#更新字体缓存
fc-cache -fv
#让字体生效
source /etc/profile
#查看字体
#fc-list
#fc-list :lang=zh
