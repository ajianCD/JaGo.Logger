## JaGo.Logger 日志模块

学习张占岭大神的架构总结，该模块主要整理日志模块的文本日志以及使用log4net日志的封装。
配置使用哪种日志方式配置路径：Config/JaGo/ConfigConstants_Logger.xml(自动生成)
```javascript
<?xml version="1.0"?>

<ConfigModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Type>File（File/Log4net任选）</Type>
  <Level>ERROR（日志记录等级）</Level>
  <ProjectName>JaGo（项目名称）</ProjectName>
</ConfigModel>

```
如果采用Log4net日志方式，请将log4net.config放置：/Config/log4net.config。如果没有配置，将无法正常记录日志。