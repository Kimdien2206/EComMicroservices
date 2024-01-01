import { Card, Table, Image, Space, Typography } from 'antd';
import type { ColumnsType } from 'antd/es/table';
import { formatNumberWithComma } from '../../../helper/utils';
import IOrder_detail from '../../../interface/OrderDetail';

const { Text } = Typography;

const { Meta } = Card;

interface DataType {
  id: number;
  name: string;
  image: string;
  color: string;
  size: string;
  quantity: number;
  price: number;
}

const columns: ColumnsType<IOrder_detail> = [
  {
    title: 'ID',
    dataIndex: 'id',
    key: 'id',
    render: (text, record) => <p>{record.id}</p>,
  },
  {
    title: 'Sản phẩm',
    key: 'name_image',
    render: (text, record) => {
      return <Space direction='horizontal'>
        <Image width={100} height={150} alt="example" src={record.product.image[0]} style={{ borderRadius: 10 }} />
        <Text>{record.product.name}</Text>
      </Space>
    },
  },
  {
    title: 'Màu',
    dataIndex: 'color',
    key: 'color',
    render: (text, record) => <p>{record.product.productItems.find((ele) => ele.id == record.itemId)?.color}</p>,
  },
  {
    title: 'Kích cỡ',
    dataIndex: 'size',
    key: 'size',
    render: (text, record) => <p>{record.product.productItems.find((ele) => ele.id == record.itemId)?.size}</p>,
  },
  {
    title: 'Số lượng',
    dataIndex: 'quantity',
    key: 'quantity',
    render: (text, record) => <p>{record.quantity}</p>,
  },
  {
    title: 'Giá',
    dataIndex: 'price',
    key: 'price',
    render: (text, record) => <p>{formatNumberWithComma(record.product.price)}</p>,
  },
];

type OrderDetailTableProps = {
  data?: IOrder_detail[]
}

const ProductOrderDetailTable = ({ data }: OrderDetailTableProps) => {
  console.log(["product", data])
  return (
    <Table columns={columns} dataSource={data} pagination={{ pageSize: 4 }} />
  )
}

export default ProductOrderDetailTable