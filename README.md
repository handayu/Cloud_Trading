# 本项目主要基于阿里云策略投资组合实时监控（WeChart）,以及未来多台服务器投资组合策略运行的统一管理
[![AppVeyor build status](https://ci.appveyor.com/api/projects/status/github/softethervpn/softethervpn?branch=master&svg=true)](https://ci.appveyor.com/project/softethervpn/softethervpn) [![Travis CI build status](https://travis-ci.org/SoftEtherVPN/SoftEtherVPN.svg?branch=master)](https://travis-ci.org/SoftEtherVPN/SoftEtherVPN) [![gitlab-ci build status](https://gitlab.com/SoftEther/SoftEtherVPN/badges/master/build.svg)](https://gitlab.com/SoftEther/SoftEtherVPN/pipelines) [![Coverity Scan Build Status](https://scan.coverity.com/projects/16304/badge.svg)](https://scan.coverity.com/projects/softethervpn-softethervpn)
　
 - 对于自己搭建交易服务器设备而言，策略交易服务器的稳定性一直是个很大的问题。在虚拟机发展迅速的当下，云服务器反而在服务器性能要求不是很高的情形下，是个比较划算的储备。云端服务器可以在99999俗称五个9的情况下365*24小时运转，
使得全天候的策略成为可能，尤其是对于交易商品cta，全球股指，CFDs以及外汇零售投资组合的团队而言。对于云端服务器的
实时监控是一个必要的维护过程，除了监控策略服务器本身的稳定性和各项硬件软件参数，还需要对策略服务器策略运行的情况，交易策略的成交，委托，风险等参数获得即时性的了解，刚好可以搭配已经全面做好Message-Notify消息通知的微信和QQ完成365*24小时提醒，由于Google和腾讯的合作，使得安卓－WeChart可以不间断唤醒消息通知，所以进程可以一直在后台。

- 笔者曾经尝试过使用WeChart的WebSocket进行对接，或者使用网页版的Http进行模拟API通信，但很遗憾的是，新申请的微信号的WebSoket无法登陆网页版，所以无法模拟完成web-http模式的通信。所以只能利用PC模拟键盘鼠标技术，和进程间的剪切版通信，完成对信息的wechart发送。
 
*** 
### 功能预览

- 一个进程往txt写入需要预警的文本信息;
- 该进程定时器定时获取,并仿制键盘操作定位屏幕位置进行输入和截图输出,结合通讯工具完成预警等;
- 预警内容包括策略信号,服务器状态等等;

- 图形识别发送过来的信息，进行消息回复;
- 网页爬虫获取华尔街见闻的365*24小时的资讯信息，并进行微信播报;
- 抓取Multicharts-中国版主力合约维护的网页信息，进行换月微信提醒;
- 定时发送服务器的相关状态(可定在开盘前);
- 微信发送+N,-N切换Multicharts的工作区(转换为快捷键并SetForeWindows)

- 进程监控，监控给出的进程是否正常工作，并微信提醒;
- TWS的进程监控，自动登陆链接;

### 正在更新的功能

- 多台交易服务器的统一监控，使用同一个微信号;

### 界面效果 - 1.静态终结果
*

![image](https://github.com/handayu/Cloud_Trading/blob/master/image/work.png)

* * *

### 技术应用？
- ThirdPartySoftWare Multicharts
- Trade Strategy交易策略,FilePrint
- Use Multicharts PowerLanguage Edit
- 事件引擎
- Windows Hook
- Net Framework4.6.1
- 网页爬虫获取
- 屏幕图形识别(文字像素)
- windows桌面键盘鼠标模拟技术

### 参与本项目？

如有兴趣的量化－程序化交易员或者团队:
   请加 QQ：578931169。
   WeChart: hanyu196910
   
   <h3 id="weibo-weixin">微信</h3>
 *「DotNet」：专注 .NET量化交易平台开发，量化交易，程序化交易，投资组合构建。
   <br><img src="https://github.com/handayu/OandaTrading/blob/master/image/wechart.jpg" width=150 height=150>
* * *

### 新增功能的初衷
- 目前团队策略服务器运行正常，工具提醒运转正常，如下图所示;
![image](https://github.com/handayu/Cloud_Trading/blob/master/image/wechart.png)

- 未来管理的策略服务器可能更多，涉及的市场更广。这就需要，在一个微信上能够和多台服务器进行交互，监控和互推信息.
需要在目前的结构上，进行稍微的变化,如下图结构。


