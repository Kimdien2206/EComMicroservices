import { Row, Col, Card, Avatar, Image, Button } from 'antd'
import React, { useEffect, useState } from 'react'
import NumberCard from '../../components/Card/NumberCard'
import OrderIcon from '../../assets/icon/bill_96px.png'
import CustomerIcon from '../../assets/icon/customer_96px.png'
import FavoriteIcon from '../../assets/icon/heart_96px.png'
import ShirtIcon from '../../assets/icon/t-shirt_96px.png'
import LineChart from '../../components/Chart/LineChart'
import UserIcon from '../../assets/icon/user_96px.png'
import pic1 from '../../assets/images/products/product-01 (1).jpg'
import FeedbackList from '../../components/List/FeedbackList'
import IProduct from '../../interface/Product'
import { fetchTopTenBestSellers } from '../../api/admin/dashboardAPI'
import { fetchTopTenMostViewed } from '../../api/productAPI'
import IOrder from '../../interface/Order'
import IUser from '../../interface/User'
import { fetchAllCustomers } from '../../api/admin/CustomerAPI'
import { fetchAllProducts } from '../../api/CustomerAPI'
import { fetchAllOrders } from '../../api/admin/OrderAPI'
import { fetchActiveProduct } from '../../api/admin/productAPI'
import { updateForecastData } from '../../api/admin/forecastAPI'
import SuccessAlert from '../../components/Alert/SuccessAlert'
import { updateRecommener } from '../../api/recommenderAPI'

const { Meta } = Card;

const Dashboard = () => {
  const [bestSaler, setBestSaler] = useState<IProduct>();
  const [mostViewed, setMostViewed] = useState<IProduct>();
  const [order, setOrder] = useState<IOrder[]>();
  const [customer, setCustomer] = useState<IUser[]>();
  const [product, setProduct] = useState<number>();

  useEffect(() => {
    fetchTopTenBestSellers().then((data) => {
      setBestSaler(data.data[0])
    })
    fetchTopTenMostViewed().then((data) => {
      setMostViewed(data.data[0])
    })
    fetchAllCustomers().then((data) => {
      setCustomer(data.data);
    })
    fetchActiveProduct().then((data) => {
      console.log(data.data[0])
      setProduct(data.data[0]);
    })
    fetchAllOrders().then((data) => {
      setOrder(data.data)
    })
  }, [])

  return (
    <div>
      <Row style={{ marginBottom: 20 }}>
        <Col>
          <Button
            type="primary"
            onClick={() => {
              updateForecastData().then(() => SuccessAlert("Đã gửi yêu cầu cập nhật dữ liệu dự báo. Vui lòng kiểm tra lại sau vài phút.")).catch(err => console.log(err));
            }}>Cập nhật dự báo</Button>
        </Col>
        <Col offset={1}>
          <Button
            type="primary"
            onClick={() => {
              updateRecommener().then(() => SuccessAlert("Đã gửi yêu cầu cập nhật hệ thống gợi ý. Vui lòng kiểm tra lại sau vài phút.")).catch(err => console.log(err));
            }}>Cập nhật hệ thống gợi ý</Button>
        </Col>
      </Row>
      <Row gutter={24} style={{ marginBottom: 20 }}>
        <Col lg={8} md={12}>
          <NumberCard title='Đơn hàng' icon={OrderIcon} description={order?.length.toString()} />
        </Col>
        <Col lg={8} md={12}>
          <NumberCard title='Khách hàng' icon={CustomerIcon} description={customer?.length.toString()} />
        </Col>
        {/* <Col lg={6} md={12}>
          <NumberCard title='Đánh giá tốt' icon={FavoriteIcon} description={'100,100'} />
        </Col> */}
        <Col lg={8} md={12}>
          <NumberCard title='Sản phẩm đang bày bán' icon={ShirtIcon} description={product?.toString()} />
        </Col>
      </Row>
      <Row gutter={24} style={{ marginBottom: 20 }}>
        <Col span={24}>
          <Card>
            <LineChart />
          </Card>
        </Col>
      </Row>
      <Row gutter={24}>
        <Col span={6}>
          <Card
            hoverable
            style={{ width: 240 }}
            cover={<Image src={bestSaler?.image[0]} />}
          >
            <Meta title="Bán chạy nhất" description={bestSaler?.name} />
          </Card>
        </Col>
        <Col span={6}>
          <Card
            hoverable
            style={{ width: 240 }}
            cover={<Image src={mostViewed?.image[0]} />}
          >
            <Meta title="Xem nhiều nhất" description={mostViewed?.name} />
          </Card>
        </Col>
        <Col span={12}>
          <FeedbackList pageSize={2} />
        </Col>
      </Row>
    </div>
  )
}

export default Dashboard