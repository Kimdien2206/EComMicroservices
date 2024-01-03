import { Button, Card, Col, Image, List, Result, Row, Space, Spin, Typography } from 'antd'
import { useContext, useEffect, useState } from 'react';
import { CheckoutContext } from '../../../context/CheckoutContext'
import { formatNumberWithComma } from '../../../helper/utils';
import { useNavigate, useParams } from 'react-router-dom';
import { validateReiceptResult } from '../../../api/paymentAPI';
import ErrorResult from '../../../components/Result/ErrorResult';
import { getOrder } from '../../../api/CustomerAPI';

interface QueryParams {
  [key: string]: string;
}

const extractQueryParams = (url: string): QueryParams => {
  const queryParams = new URLSearchParams(url);
  console.log(queryParams)
  const params: QueryParams = {};

  queryParams.forEach((value, key) => {
    params[key] = value;
  });

  return params;
};

const PaymentResultSuccess = () => {
  const checkout = useContext(CheckoutContext);
  const [isValidateError, setIsValidateError] = useState(false);
  const { orderID } = useParams<{ orderID: string }>();
  const [isLoading, setIsLoading] = useState(true);
  const nav = useNavigate();
  useEffect(() => {
    if (orderID) {
      console.log("🚀 ~ file: PaymentResultSuccess.tsx:34 ~ useEffect ~ orderID:", orderID)
      const currentUrl = window.location.search;
      const vnPayResQuery = extractQueryParams(currentUrl);
      console.log("🚀 ~ file: PaymentResultSuccess.tsx:37 ~ useEffect ~ vnPayResQuery:", vnPayResQuery)
      validateReiceptResult(vnPayResQuery['vnp_TxnRef'], vnPayResQuery).then(({ data }) => {
        console.log("🚀 ~ file: PaymentResultSuccess.tsx:38 ~ validateReiceptResult ~ data:", data)
        getOrder(orderID).then(({ data: orderRes }) => {
          console.log("🚀 ~ file: PaymentResultSuccess.tsx:40 ~ getOrder ~ orderRes:", orderRes)
          checkout?.setOrder(orderRes[0]);
        })
      }).catch((err) => {
        setIsValidateError(true);
        console.error(err);
      }).finally(() => setIsLoading(false));
    }
  }, [])
  return (
    <Spin spinning={isLoading} style={{ width: "100wh" }}>
      {!isValidateError ?
        (<div className='centerflex' style={{ flexDirection: 'column', rowGap: 50, padding: '20px 0' }}>
          <Row style={{ width: '80%' }}>
            <Col span={12}>
              <Card bordered >
                <Result
                  status="success"
                  title="Thanh toán thành công"
                  subTitle={<Space direction='vertical'>
                    <p>Thông tin đơn hàng:</p>
                    <p>Họ tên: {checkout?.order?.firstname + " " + checkout?.order?.lastname}</p>
                    <p>Số điện thoại: {checkout?.order?.phoneNumber}</p>
                    <p>Địa chỉ: {checkout?.order?.address}</p>
                    <p>Cảm ơn bạn đã mua hàng.</p>
                    <p>Nếu có bất kì vấn đề gì cần hỗ trợ, hãy liên lạc với của hàng qua số điện thoại 0912324274</p>
                  </Space>}
                  extra={[
                    <Button type="primary" key="console" onClick={() => nav("/")}>
                      Về trang chủ
                    </Button>
                  ]}
                />
              </Card>
            </Col>
            <Col offset={2} span={10}>
              <Card bordered style={{ width: '100%' }} title={'Chi tiết đơn hàng'} >
                <List
                  itemLayout="horizontal"
                  dataSource={
                    checkout?.order?.orderDetails
                  }
                  renderItem={(item, index) => (
                    <List.Item key={item.id}>
                      <List.Item.Meta
                        avatar={<Image width={80} height={110} src={item.product.image[0]} alt='slug' style={{ borderRadius: 5 }} />}
                        title={item.product.name}
                        description={`x ${item.quantity}`}
                      />
                      <div>{formatNumberWithComma(item.product.price * item.quantity)}</div>
                    </List.Item>
                  )}
                  pagination={{
                    pageSize: 3,
                  }}
                  footer={null}
                />
              </Card>
            </Col>
          </Row>
        </div >) : (<ErrorResult />)}
    </Spin>
  )
}

export default PaymentResultSuccess