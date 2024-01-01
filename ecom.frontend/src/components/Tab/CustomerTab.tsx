import React from 'react';
import { Tabs } from 'antd';
import ProductCollectionDetailTable from '../Table/Product/ProductDetailTable.Collection';
import ReceiptTable from '../Table/Receipt/ReceiptTable';
import OrderTable from '../Table/Order/OrderTable';

const onChange = (key: string) => {
  console.log(key);
};

const tabItems = new Array(2).fill(null).map((_, i) => {
  const id = String(i + 1);
  return {
    label: i === 0 ? `Sản phẩm đã xem` : 'Đơn hàng đã mua',
    key: id,
    children: i === 0 ? <ProductCollectionDetailTable /> :
      <OrderTable />
  };
});

const CustomerTab: React.FC = () => (
  <Tabs
    onChange={onChange}
    type="card"
    items={tabItems}
  />
);

export default CustomerTab;