| Service         | Resource     | Method | Endpoint                                              | Port   |
|-----------------|-------------|--------|-------------------------------------------------------|--------|
| EventCatalog    | Category    | GET    | /api/Category                                         | 5000   |
| EventCatalog    | Event       | GET    | /api/Event                                            | 5000   |
| EventCatalog    | Event       | GET    | /api/Event/{eventId}                                  | 5000   |
| ShoppingBasket  | BasketLines | GET    | /api/baskets/{basketId}/basketlines                   | 5001   |
| ShoppingBasket  | BasketLines | POST   | /api/baskets/{basketId}/basketlines                   | 5001   |
| ShoppingBasket  | BasketLines | GET    | /api/baskets/{basketId}/basketlines/{basketLineId}    | 5001   |
| ShoppingBasket  | BasketLines | PUT    | /api/baskets/{basketId}/basketlines/{basketLineId}    | 5001   |
| ShoppingBasket  | BasketLines | DELETE | /api/baskets/{basketId}/basketlines/{basketLineId}    | 5001   |
| ShoppingBasket  | Baskets     | GET    | /api/baskets/{basketId}                               | 5001   |
| ShoppingBasket  | Baskets     | POST   | /api/baskets                                          | 5001   |
| ShoppingBasket  | Baskets     | PUT    | /api/baskets/{basketId}/coupon                        | 5001   |
| ShoppingBasket  | Baskets     | POST   | /api/baskets/checkout                                 | 5001   |
| ShoppingBasket  | BasketEvent | GET    | /api/basketevent                                      | 5001   |
| Discount        | Code        | GET    | /Discount/code/{code}                                 | 5002   |
| Discount        | Coupon      | GET    | /Discount/{couponId}                                  | 5002   |
| Discount        | Error       | GET    | /Discount/error/{couponId}                            | 5002   |
| Discount        | Use         | PUT    | /Discount/use/{couponId}                              | 5002   |
| Order           | UserOrders  | GET    | /api/order/user/{userId}                              | 5003   |

---

| Microservice        | Local Env   | Docker Env   | Docker Inside |
|---------------------|-------------|--------------|--------------|
| EventCatalog        | 5000-5050   | 6000-6050    | 8080-8081    |
| ShoppingBasket      | 5001-5051   | 6001-6051    | 8080-8081    |
| Discount            | 5002-5052   | 6002-6052    | 8080-8081    |
| Ordering            | 5003-5053   | 6003-6053    | 8080-8081    |
| Payment             | 5004-5054   | 6004-6054    | 8080-8081    |
| Marketing           | 5005-5055   | 6005-6055    | 8080-8081    |


