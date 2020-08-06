# E-Commerce API

## Customer

| Field | Type   | Description   |
| ----- | ------ | ------------- |
| id    | number | customer id   |
| name  | string | customer name |

## Products

| Field | Type   | Description   |
| ----- | ------ | ------------- |
| id    | number | product id    |
| name  | string | product name  |
| price | number | product price |

## Cart

| Field            | Type   | Description      |
| ---------------- | ------ | ---------------- |
| customer_id      | number | customer id      |
| product_id       | number | product id       |
| product_quantity | number | product quantity |

## Docker

```bash
docker pull postgres

docker run --name e-commerce-postgres -e POSTGRES_USER=ecommerce -e POSTGRES_PASSWORD=ecommerce -d postgres
```
