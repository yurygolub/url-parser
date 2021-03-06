# Url Parser

## Description

В текстовом файле построчно хранится информация об Url-адресах, представленных в виде `<scheme>://<host>/<url-path>?<parameters>`, где сегмент `parameters` - это набор пар вида `key1=value1&key2=value2...keyN=valueN`, при этом сегменты `url‐path` и `parameters` или сегмент `parameters` могут отсутствовать. 

 - Разработать систему типов для конвертирования данных, полученных на основе разбора информации текстового файла в XML-документ. Например, для текстового файла с Url-адресами 

    https://github.com/AnzhelikaKravchuk?tab=repositories   
    https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU   
    https://habrahabr.ru/company/it-grad/blog/341486/   

результирующим является XML-документ вида 

![](/XML.Task.png)
 - Предусмотреть возможность получения XML-документа, используя любую XML технологию -  XmlReader/XmlWriter, X-DOM.
 - Для тех Url-адресов, которые не совпадают с указанным шаблоном, выполнить логирование информации (предусмотреть возможность замены лог-фреймворка, в качестве логгера по умолчанию использовать `NLog` с логирование в файл), отметив указанные строки, как необработанные.
 - Продемонстрировать работу на примере консольного приложения.
 - Для организации проектов solution-а использовать `Stairway`-паттерн.
 - Для разрешения зависимостей использовать типы `Microsoft.Extensions.DependencyInjection`.
 - Для тестирования основой функциональности использовать NUnit и Moq фреймворки.

*При реализации системы типов учитывать возможность их использования в случае, когда в исходном текстовом файле информация об Url-адресах изменится на другую, иерархически представимую информацию.
