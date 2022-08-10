# hw-03
## SkillFactory: CDEV. Итоговый проект модуля 7 
Проект имеет цель показать понимание принципов ООП преподанных в модуле, и возможностей их реализации на языке C#. 
Некоторые методы оставлены без реализации или имеют неполную реализацию так как для достижения целей проекта в этом нет необходимости. 


Проект реализует следующие задачи
```
* Использование наследования;
	Kлассы: HomeDelivery,PickPointDelivery,ShopDelivery

* Использование абстрактных классов или членов класса;
	Класс Delivery

* Использование принципов инкапсуляции;
	Обект Products класса Order

* Использование переопределений методов/свойств;
	Классы: HomeDelivery,PickPointDelivery,ShopDelivery. 
	Методы: GetDeliveryStatusInfo,GetDeliveryServiceInfo
	Свойства : Status

* Использование минимум 4 собственных классов;
	Классы:Product,ProductCollection,СouriersService,DeliveryStatusInfo

* Использование конструкторов классов с параметрами;
	Классы: HomeDelivery,PickPointDelivery,ShopDelivery

* Использование обобщений;
	Классы: Order

* Использование свойств;
	Классы: HomeDelivery,PickPointDelivery,ShopDelivery,Product,СouriersService

* Использование композиции классов.
	Классы: Order объект products

* Использование статических элементов или классов;
	Класс DeliveryStatusInfo, поле OrderNum класса OrderBase 

* Использование обобщенных методов;
	Класс Order метод ChangeDelivery

* Использование свойств с логикой в get и/или set блоках.
	Класс DeliveryStatusInfo свойство StatusDict

* Использование методов расширения;
	Класс ProductExtensions метод GetEan13
	
* Использование наследования обобщений;
	Класс ProductCollection

* Использование агрегации классов;
	Классы: HomeDelivery объект СourierService   

* Использование индексаторов;
	Класс ProductCollection

* Использование перегруженных операторов.
	Класс: Product, операторы == , != .
```
