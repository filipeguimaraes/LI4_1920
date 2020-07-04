import React from 'react'
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import AccountBalanceWalletIcon from '@material-ui/icons/AccountBalanceWallet';

const MyCard = ({ money }) => (
  <div style={{ padding: '30px' }}>
    <Card style={{ padding: '30px' }}>

      <Typography variant="h3" component="h3" >
        <AccountBalanceWalletIcon fontSize="large" /> My Wallet
        </Typography>

      <h2 style={{textAlign: "right"}}>{money} $</h2>
    </Card>
  </div>
)

export default MyCard
