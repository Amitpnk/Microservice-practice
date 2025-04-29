| Services | Resource       | Method | Endpoint                                   |
|------------------|----------------|--------|-------------------------------------------|
| EventCatalog    | Category       | GET    | /api/Category                             |
| EventCatalog    | Event          | GET    | /api/Event                                |
| EventCatalog    | Event          | GET    | /api/Event/{eventId}                      |
| ShoppingBasket  | BasketLines    | GET    | /api/baskets/{basketId}/basketlines       |
| ShoppingBasket  | BasketLines    | POST   | /api/baskets/{basketId}/basketlines       |
| ShoppingBasket  | BasketLines    | GET    | /api/baskets/{basketId}/basketlines/{basketLineId} |
| ShoppingBasket  | BasketLines    | PUT    | /api/baskets/{basketId}/basketlines/{basketLineId} |
| ShoppingBasket  | BasketLines    | DELETE | /api/baskets/{basketId}/basketlines/{basketLineId} |
| ShoppingBasket  | Baskets        | GET    | /api/baskets/{basketId}                   |
| ShoppingBasket  | Baskets        | POST   | /api/baskets                              |
| ShoppingBasket  | Baskets        | PUT    | /api/baskets/{basketId}/coupon            |




Discount


GET
/Discount/code/{code}


GET
/Discount/{couponId}


GET
/Discount/error/{couponId}


PUT
/Discount/use/{couponId}


Order


GET
/api/order/user/{userId}