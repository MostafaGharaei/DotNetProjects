# DotNetProjects — Project Context File (Enhanced Version)
این فایل به‌عنوان مرجع ثابت برای Copilot Web و توسعه‌دهندگان استفاده می‌شود تا ساختار، معماری، الگوهای طراحی و قوانین پروژه همیشه مشخص باشد.

---

# 📘 هدف پروژه
این ریپازیتوری مجموعه‌ای از **پروژه‌های آموزشی C# و .NET** است که هر کدام یک **Design Pattern** یا **Architectural Pattern** را با کد تمیز، استاندارد و قابل اجرا نمایش می‌دهند.

هدف اصلی:
- آموزش عملی پترن‌ها
- نمایش معماری صحیح در .NET
- ایجاد یک مرجع آموزشی برای GitHub
- استفاده در Copilot Web بدون نیاز به توضیح مجدد

---

# 🏗 معماری کلی Solution
Solution: **DotNetProjects**

Folder اصلی: **02-DesignPatterns**

هر پترن:
- یک پروژهٔ Class Library مستقل دارد
- یک Demo در پروژهٔ کنسول دارد
- ساختار و namespace مخصوص خودش را دارد

پروژهٔ اجرا: **DesignPatternsConsole**

---

# 📦 پروژه‌ها و پترن‌ها

## 1) SingletonDemo
**هدف:** ایجاد یک Logger با یک Instance واحد  
**ویژگی‌ها:**
- Thread-Safe  
- Lazy<T>  
- Log به فایل و Console  
- Demo در کنسول

---

## 2) FactoryDemo
**هدف:** ساخت آبجکت‌های مختلف Notification بدون وابستگی مستقیم  
**ویژگی‌ها:**
- NotificationFactory  
- Email, SMS, Push, Slack  
- متدهای Create و TryCreate  
- مدیریت خطاها

---

## 3) StrategyDemo
**هدف:** تغییر رفتار پرداخت بدون تغییر در کلاس اصلی  
**ویژگی‌ها:**
- ShoppingCart  
- IPaymentStrategy  
- استراتژی‌های پرداخت: CreditCard, PayPal, Bitcoin, Cash  
- Demo کامل Checkout

---

## 4) RepositoryDemo
**هدف:** جداسازی لایهٔ Data Access  
**ویژگی‌ها:**
- CustomerRepository  
- مدل Customer  
- متدهای جستجو، فیلتر، شمارش  
- LINQ و record

---

## 5) UnitOfWorkDemo
**هدف:** مدیریت تراکنش و تغییرات  
**ویژگی‌ها:**
- UnitOfWork  
- ProductRepository  
- OrderRepository  
- TrackChange  
- Update Stock  
- Commit

---

## 6) DecoratorDemo
**هدف:** افزودن رفتار داینامیک بدون تغییر کلاس اصلی  
**ویژگی‌ها:**
- INotifier  
- EmailNotifier  
- SmsDecorator  
- SlackDecorator  
- زنجیرهٔ Decorator

---

## 7) MediatorDemo
**هدف:** مدیریت ارتباط بین آبجکت‌ها بدون وابستگی مستقیم  
**ویژگی‌ها:**
- IChatMediator  
- ChatMediator  
- User  
- ارسال پیام از طریق Mediator

---

## 8) ObserverDemo
**هدف:** اطلاع‌رسانی خودکار هنگام تغییر وضعیت  
**ویژگی‌ها:**
- ISubject  
- IObserver  
- Product (Subject)  
- CustomerObserver  
- تغییر قیمت → Notify

---

## 9) AdapterDemo
**هدف:** سازگار کردن سیستم قدیمی با اینترفیس جدید  
**ویژگی‌ها:**
- INewPayment  
- OldPaymentSystem  
- PaymentAdapter  
- تبدیل decimal → double

---

## 10) CQRSDemo
**هدف:** جداسازی کامل Query و Command  
**ویژگی‌ها:**
- Queries: GetProductsQuery, GetProductByIdQuery  
- Commands: AddProductCommand, UpdatePriceCommand  
- Database (In-Memory)  
- record models  
- بدون وابستگی خارجی

---

# 🧱 قوانین کدنویسی و استانداردها

## نسخه‌ها
- **.NET 8+**
- **C# 12+**
- استفاده از قابلیت‌های جدید:
  - record / record struct  
  - with expression  
  - using var  
  - LINQ مدرن  
  - الگوهای جدید switch  
  - Lazy<T>  
  - Minimal APIs (در آینده)

## معماری
- رعایت SOLID  
- رعایت Clean Code  
- هر پترن در یک پروژهٔ مستقل  
- Demoها در کنسول  
- نام‌گذاری استاندارد  
- namespaceهای جداگانه

## مدل‌ها
- استفاده از record برای مدل‌ها  
- Immutable بودن تا حد ممکن  
- استفاده از with برای آپدیت‌ها

---

# 🔧 وابستگی‌ها
- فقط کتابخانه‌های استاندارد .NET  
- بدون NuGet اضافی  
- بدون وابستگی خارجی

---

# 📘 نحوهٔ استفاده در Copilot Web
در هر چت جدید، فقط این جمله را بنویسید:

**"از Context پروژهٔ من استفاده کن:"**  
https://github.com/MostafaGharaei/DotNetProjects/ProjectContext.md

Copilot باید تمام کدها، معماری، پترن‌ها و ساختار پروژه را بر اساس این فایل ادامه دهد.

---

# ✨ نکتهٔ مهم
اگر پروژه بزرگ‌تر شد، فقط این فایل را آپدیت کنید.  
Copilot همیشه نسخهٔ جدید را می‌خواند و دیگر نیازی به توضیح دوباره نیست.

