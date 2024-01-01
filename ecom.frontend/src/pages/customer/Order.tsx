import { Space, List, Row, Button, Image } from 'antd';
import Title from 'antd/es/typography/Title';
import IOrder from '../../interface/Order';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { getOrdersByPhoneNumber } from '../../api/CustomerAPI';
import LocalStorage from '../../helper/localStorage';
import { formatNumberWithComma } from '../../helper/utils';

const IconText = ({ icon, text }: { icon: React.FC; text: string }) => (
  <Space>
    {React.createElement(icon)}
    {text}
  </Space>
);

const Order = () => {
  const [data, setData] = useState<IOrder[]>();
  const [loading, setLoading] = useState(false)
  const navigate = useNavigate();

  useEffect(() => {
    getOrdersByPhoneNumber(LocalStorage.getItem('user').phoneNumber).then((data) => {
      setData(data.data)
      console.log("🚀 ~ file: Order.tsx:25 ~ getOrdersByPhoneNumber ~ data.data:", data.data)
    })
  }, [])

  return (
    <Space className='svgBg' style={{ width: '100%', height: '100%', justifyContent: 'center', alignItems: 'center' }}>
      <Space direction='vertical' style={{ gap: 20, margin: '20px 0px' }}>
        {data?.map((item) => <List
          pagination={{
            pageSize: 3,
          }}
          bordered
          header={<Space style={{ width: '100%', display: 'flex', justifyContent: 'space-between' }}>
            <Title level={2}>Đơn hàng {item.id}</Title>
            <Button type='primary' onClick={() => navigate(`/orders/${item.id}`)}>Xem chi tiết</Button>
          </Space>}
          footer={<Title level={4} style={{ textAlign: 'end' }}> Tổng giá trị: {formatNumberWithComma(item.totalCost)}</Title>}
          style={{ width: '60vw', background: 'white' }}
          itemLayout="vertical"
          size="default"
          dataSource={item.orderDetails}
          renderItem={(detail) => {
            return (
              <List.Item
                key={detail.product.name}
                extra={
                  <Image
                    width={100}
                    alt="logo"
                    src={detail.product.image[0]}
                    style={{ borderRadius: 10 }}
                  />
                }
              >
                <List.Item.Meta
                  title={detail.product.name}
                />
                <Row>
                  {`Số lượng: ${detail?.quantity}`}
                </Row>
                <Row>
                  {`Phân loại: ${detail.product.productItems.find(e => e.id == detail.itemId)?.color} ${detail.product.productItems.find(e => e.id == detail.itemId)?.size}`}
                </Row>
                <Row>{`Giá tiền: ${formatNumberWithComma(detail.product.price)}`}</Row>
              </List.Item>
            )
          }}
        />)}

      </Space>
    </Space>
  )
}

export default Order