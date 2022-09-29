use [LIBRERIA 113857]

-- SubConsultas 29/9/2022


-- listar los datos y la diferencia entre su precio y el precio del articulo mas caro (diferencia de precios)

select descripcion, pre_unitario,(select max(pre_unitario) from articulos) - pre_unitario 'precio mas caro'
from articulos


-- listar los articulos descripcion, precio y el promedio de los precios al que fue mas vendido ese articulo

select cod_articulo,descripcion, pre_unitario, (select avg(pre_unitario) from detalle_facturas where cod_articulo = a.cod_articulo ) 'prom. simple precio de venta', --referencia externa
(select sum(pre_unitario*cantidad)/sum(cantidad) from detalle_facturas where cod_articulo=a.cod_articulo) 'prom. ponderado precio de venta'
from articulos a


--listar los datos de la factura del año en curso mostrando ademas el total sin mostrar los detalles

select f.nro_factura, fecha, cod_cliente, cod_vendedor
from facturas f join (select nro_factura, sum(cantidad*pre_unitario) 'total' from detalle_facturas group by nro_factura) as f2 on f2.nro_factura = f.nro_factura 
where year(fecha) = year(getdate())


--listar el precio actual de los articulos y el precio historico vendido mas barato

select descripcion, pre_unitario,
(select min(pre_unitario) from detalle_facturas df where a.cod_articulo=df.cod_articulo )'precio vta. mas barato'
from articulos a


--Generar un reporte un listado con la código y descripción de los artículos
--su precio actual, el precio más barato y el más caro al que se vendió hace
--5 años.







